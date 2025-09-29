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
    /// オフラインデータシリアライザのラッパー
    /// 2008.07.18 23011 noguchi
    /// 2012.11.14 23011 noguchi 例外処理を追加
    /// </summary>
    public class OfflineDataSerializer
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public OfflineDataSerializer()
        {

        }

        private _OfflineDataSerializer _serializer = new _OfflineDataSerializer();

        private OfflineDataSerializer2 _serializer2 = new OfflineDataSerializer2();

        #region public Method CustomSerializer Object Serialize関連
        
        /// <summary>
        /// シリアライズ
        /// </summary>
        /// <param name="classId">クラスID</param>
        /// <param name="keyList">キーList</param>
        /// <param name="data">シリアライズ対象データ</param>
        /// <param name="serializedData">シリアライズ結果データ</param>
        /// <returns>STATUS</returns>
        public int Serialize(string classId, string[] keyList, object data, out byte[] serializedData)
        {
            //シリアライズは新オフライン保存部品のみで行う
            serializedData = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            //2008.09.11 23011 noguchi 以前のシリアライズ部品と同じ動作にした >>
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
        /// シリアライズ
        /// </summary>
        /// <param name="classId">クラスID</param>
        /// <param name="keyList">キーList</param>
        /// <param name="data">シリアライズ対象データ</param>
        /// <returns>STATUS</returns>
        public int Serialize(string classId, string[] keyList, object data)
        {
            //シリアライズは新オフライン保存部品のみで行う

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            //2008.09.11 23011 noguchi 以前のシリアライズ部品と同じ動作にした >>
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
        /// シリアライズ
        /// </summary>
        /// <param name="classId">クラスID</param>
        /// <param name="keyList">キーList</param>
        /// <param name="data">シリアライズ対象データ</param>
        /// <param name="targetDir">処理対象ディレクトリ</param>
        /// <returns>STATUS</returns>
        public int Serialize(string classId, string[] keyList, object data, string targetDir)
        {
            //シリアライズは新オフライン保存部品のみで行う

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            //2008.09.11 23011 noguchi 以前のシリアライズ部品と同じ動作にした >>
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
        /// デシリアライズ
        /// </summary>
        /// <param name="classId">クラスID</param>
        /// <param name="keyList">キーList</param>
        /// <param name="deserializeData">デシリアライズ対象データ</param>
        /// <returns>デシリアライズ結果</returns>
        public object DeSerialize(string classId, string[] keyList, byte[] deserializeData)
        {
            //2008.08.12 23011 noguchi del >>
            ////新しいファイルがあれば新しいファイルを読み出す。
            ////新しいファイルがなければ旧処理に制御を移す
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

            //デシリアライズに失敗したら旧処理でデシリアライズしてみる
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

            //2012.11.14 23011 noguchi 例外処理追加 >>
            try
            {
                //>> 2012.11.14 23011 noguchi 例外処理追加

                //シリアライザ２でデシリアライズしてもデータが取得できなかった場合には旧処理でデシリアライズしてみる
                if (retObj == null)
                {
                    //2010.05.07 noguchi del
                    //retObj = _serializer.DeSerialize(classId, keyList);
                    retObj = _serializer.DeSerialize(classId, keyList, deserializeData);
                }
                //2012.11.14 23011 noguchi 例外処理追加 >>
            }
            catch
            {
                //例外の場合にはデータなしとする
            }
            //>> 2012.11.14 23011 noguchi 例外処理追加

            return retObj;
        }

        /// <summary>
        /// デシリアライズ
        /// </summary>
        /// <param name="classId">クラスID</param>
        /// <param name="keyList">キーList</param>
        /// <returns>デシリアライズ結果</returns>
        public object DeSerialize(string classId, string[] keyList)
        {
            //新しいファイルがあれば新しいファイルを読み出す。
            //新しいファイルがなければ旧処理に制御を移す
            object retObj = null;

            //2012.11.14 23011 noguchi 例外処理追加 >>
            try
            {
                //>> 2012.11.14 23011 noguchi 例外処理追加
                if (_serializer2.Exists(classId, keyList))
                {
                    retObj = _serializer2.Deserialize(classId, keyList);
                }
                else
                {
                    retObj = _serializer.DeSerialize(classId, keyList);
                }
                //2012.11.14 23011 noguchi 例外処理追加 >>
            }
            catch
            {
                //例外時にはデータなしとする
            }
            //>> 2012.11.14 23011 noguchi 例外処理追加

            return retObj;
        }

        /// <summary>
        /// デシリアライズ
        /// </summary>
        /// <param name="classId">クラスID</param>
        /// <param name="keyList">キーList</param>
        /// <param name="targetDir">処理対象ディレクトリ</param>
        /// <returns>デシリアライズ結果</returns>
        public object DeSerialize(string classId, string[] keyList, string targetDir)
        {
            //新しいファイルがあれば新しいファイルを読み出す。
            //新しいファイルがなければ旧処理に制御を移す
            object retObj = null;

            //2012.11.14 23011 noguchi 例外処理追加 >>
            try
            {
                //>> 2012.11.14 23011 noguchi 例外処理追加

                //2008.08.12 23011 noguchi ファイル存在確認処理をディレクトリ指定でするように修正
                //if (_serializer2.Exists(classId, keyList))
                if (_serializer2.Exists(classId, keyList, targetDir))
                {
                    retObj = _serializer2.Deserialize(classId, keyList, targetDir);
                }
                else
                {
                    retObj = _serializer.DeSerialize(classId, keyList, targetDir);
                }
                //2012.11.14 23011 noguchi 例外処理追加 >>
            }
            catch
            {
                //例外時にはデータなしとする
            }
            //>> 2012.11.14 23011 noguchi 例外処理追加

            return retObj;
        }
        #endregion

        #region public Method String[] Serialize関連
        /// <summary>
        /// シリアライズ
        /// </summary>
        /// <param name="classId">クラスID</param>
        /// <param name="keyList">キーList</param>
        /// <param name="data">シリアライズ対象データ</param>
        /// <returns>STATUS</returns>
        public int SerializeString(string classId, string[] keyList, string[] data)
        {
            //シリアライズは新オフライン保存部品のみで行う

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            //2008.09.11 23011 noguchi 以前のシリアライズ部品と同じ動作にした >>
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
        /// シリアライズ
        /// </summary>
        /// <param name="classId">クラスID</param>
        /// <param name="keyList">キーList</param>
        /// <param name="data">シリアライズ対象データ</param>
        /// <param name="targetDir">処理対象ディレクトリ</param>
        /// <returns>STATUS</returns>
        public int SerializeString(string classId, string[] keyList, string[] data, string targetDir)
        {
            //シリアライズは新オフライン保存部品のみで行う

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            //2008.09.11 23011 noguchi 以前のシリアライズ部品と同じ動作にした >>
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
        /// デシリアライズ
        /// </summary>
        /// <param name="classId">クラスID</param>
        /// <param name="keyList">キーList</param>
        /// <returns>デシリアライズ結果</returns>
        public string[] DeSerializeString(string classId, string[] keyList)
        {
            //新しいファイルがあれば新しいファイルを読み出す。
            //新しいファイルがなければ旧処理に制御を移す
            string[] retStr = null;

            //2012.11.14 23011 noguchi 例外処理追加 >>
            try
            {
                //>> 2012.11.14 23011 noguchi 例外処理追加

                if (_serializer2.Exists(classId, keyList))
                {
                    retStr = _serializer2.Deserialize(classId, keyList) as string[];
                }
                else
                {
                    retStr = _serializer.DeSerializeString(classId, keyList) as string[];
                }

                //2012.11.14 23011 noguchi 例外処理追加 >>
            }
            catch
            {
                //例外時にはデータなしとする
            }
            //>> 2012.11.14 23011 noguchi 例外処理追加

            return retStr;
        }

        /// <summary>
        /// デシリアライズ
        /// </summary>
        /// <param name="classId">クラスID</param>
        /// <param name="keyList">キーList</param>
        /// <param name="targetDir">処理対象ディレクトリ</param>
        /// <returns>デシリアライズ結果</returns>
        public string[] DeSerializeString(string classId, string[] keyList, string targetDir)
        {
            //新しいファイルがあれば新しいファイルを読み出す。
            //新しいファイルがなければ旧処理に制御を移す
            string[] retStr = null;

            //2012.11.14 23011 noguchi 例外処理追加 >>
            try
            {
                //>> 2012.11.14 23011 noguchi 例外処理追加

                //2008.08.12 23011 noguchi ファイルの存在チェックをディレクトリ指定で行うように修正
                //if (_serializer2.Exists(classId, keyList))
                if (_serializer2.Exists(classId, keyList, targetDir))
                {
                    retStr = _serializer2.Deserialize(classId, keyList, targetDir) as string[];
                }
                else
                {
                    retStr = _serializer.DeSerializeString(classId, keyList, targetDir) as string[];
                }
                //2012.11.14 23011 noguchi 例外処理追加 >>
            }
            catch
            {
                //例外時にはデータなしとする
            }
            //>> 2012.11.14 23011 noguchi 例外処理追加

            return retStr;
        }
        #endregion

        #region public Method byte[] Serialize 関連
        /// <summary>
        /// シリアライズ
        /// </summary>
        /// <param name="classId">クラスID</param>
        /// <param name="keyList">キーList</param>
        /// <param name="data">シリアライズ対象データ</param>
        /// <returns>STATUS</returns>
        public int SerializeByte(string classId, string[] keyList, byte[] data)
        {
            //シリアライズは新オフライン保存部品のみで行う

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            //2008.09.11 23011 noguchi 以前のシリアライズ部品と同じ動作にした >>
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
        /// シリアライズ
        /// </summary>
        /// <param name="classId">クラスID</param>
        /// <param name="keyList">キーList</param>
        /// <param name="data">シリアライズ対象データ</param>
        /// <param name="targetDir">処理対象ディレクトリ</param>
        /// <returns>STATUS</returns>
        public int SerializeByte(string classId, string[] keyList, byte[] data, string targetDir)
        {
            //シリアライズは新オフライン保存部品のみで行う

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            //2008.09.11 23011 noguchi 以前のシリアライズ部品と同じ動作にした >>
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
        /// デシリアライズ
        /// </summary>
        /// <param name="classId">クラスID</param>
        /// <param name="keyList">キーList</param>
        /// <returns>デシリアライズ結果</returns>
        public byte[] DeSerializeByte(string classId, string[] keyList)
        {
            //新しいファイルがあれば新しいファイルを読み出す。
            //新しいファイルがなければ旧処理に制御を移す
            byte[] retByte = null;

            //2012.11.14 23011 noguchi 例外処理追加 >>
            try
            {
                //>> 2012.11.14 23011 noguchi 例外処理追加

                if (_serializer2.Exists(classId, keyList))
                {
                    retByte = _serializer2.Deserialize(classId, keyList) as byte[];
                }
                else
                {
                    retByte = _serializer.DeSerializeByte(classId, keyList) as byte[];
                }
                //2012.11.14 23011 noguchi 例外処理追加 >>
            }
            catch
            {
                //例外時にはデータなしとする
            }
            //>> 2012.11.14 23011 noguchi 例外処理追加

            return retByte;
        }

        /// <summary>
        /// デシリアライズ
        /// </summary>
        /// <param name="classId">クラスID</param>
        /// <param name="keyList">キーList</param>
        /// <param name="targetDir">処理対象ディレクトリ</param>
        /// <returns>デシリアライズ結果</returns>
        public byte[] DeSerializeByte(string classId, string[] keyList, string targetDir)
        {
            //新しいファイルがあれば新しいファイルを読み出す。
            //新しいファイルがなければ旧処理に制御を移す

            byte[] retByte = null;

            //2012.11.14 23011 noguchi 例外処理追加 >>
            try
            {
                //>> 2012.11.14 23011 noguchi 例外処理追加

                //2008.08.12 23011 noguchi ファイルの存在チェックをディレクトリ指定して行うように修正
                //if (_serializer2.Exists(classId, keyList))
                if (_serializer2.Exists(classId, keyList, targetDir))
                {
                    retByte = _serializer2.Deserialize(classId, keyList, targetDir) as byte[];
                }
                else
                {
                    retByte = _serializer.DeSerializeByte(classId, keyList, targetDir) as byte[];
                }
                //2012.11.14 23011 noguchi 例外処理追加 >>
            }
            catch
            {
                //例外時にはデータなしとする
            }
            //>> 2012.11.14 23011 noguchi 例外処理追加

            return retByte;
        }
        #endregion

        #region public Method 共通メソッド
        /// <summary>
        /// シリアライズファイル削除
        /// </summary>
        /// <param name="classId">クラス名</param>
        /// <param name="keyList">KEYリスト</param>
        /// <returns>STATUS</returns>
        public int Delete(string classId, string[] keyList)
        {
            //新、旧ファイル両方を削除する
            _serializer.Delete(classId, keyList);
            _serializer2.Delete(classId, keyList);

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <summary>
        /// シリアライズファイル削除
        /// </summary>
        /// <param name="classId">クラス名</param>
        /// <param name="keyList">KEYリスト</param>
        /// <param name="targetDir">処理対象ディレクトリ</param>
        /// <returns>STATUS</returns>
        public int Delete(string classId, string[] keyList, string targetDir)
        {
            //新、旧ファイル両方を削除する
            _serializer.Delete(classId, keyList, targetDir);
            _serializer2.Delete(classId, keyList, targetDir);

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <summary>
        /// シリアライズファイル存在チェック
        /// </summary>
        /// <param name="classId">クラス名</param>
        /// <param name="keyList">KEYリスト</param>
        /// <returns>T:有り F:無し</returns>
        public bool Exists(string classId, string[] keyList)
        {
            return _serializer.Exists(classId, keyList) || _serializer2.Exists(classId, keyList);
        }

        /// <summary>
        /// シリアライズファイル存在チェック
        /// </summary>
        /// <param name="classId">クラス名</param>
        /// <param name="keyList">KEYリスト</param>
        /// <param name="targetDir">処理対象ディレクトリ</param>
        /// <returns>T:有り F:無し</returns>
        public bool Exists(string classId, string[] keyList, string targetDir)
        {
            return _serializer.Exists(classId, keyList, targetDir) || _serializer2.Exists(classId, keyList, targetDir);
        }

        #endregion

    }

}

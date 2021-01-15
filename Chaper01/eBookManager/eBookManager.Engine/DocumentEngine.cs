using System;
using System.IO;

namespace eBookManager.Engine
{
    public class DocumentEngine
    {
        public (
            DateTime created,
            DateTime dateLastAccessed,
            string fileName,
            string extension,
            long fileSize,
            bool error) GetFileProperties(string filePath)
        {
            var returnTuple = (
                created: DateTime.MinValue,
                lastAccessed: DateTime.MinValue,
                fileName: "",
                extension: "",
                fileSize: 0L,
                error: false);
            try
            {
                FileInfo fi = new FileInfo(filePath);
                fi.Refresh();
                returnTuple = (
                    fi.CreationTime,
                    fi.LastAccessTime,
                    fi.Name,
                    fi.Extension,
                    fi.Length,
                    false);
            }
            catch
            {
                returnTuple.error = true;
            }
            return returnTuple;
        }
    }
}


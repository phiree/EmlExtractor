using System;
using System.Collections.Generic;
using System.Text;
using EEModel;
using EEBiz;
using System.IO;
using EEPersistant;
namespace EEBiz
{
    public class ExtractService
    {
         IPersistent  persistent = new SqlitePersistent();
        public  void ExtractFromFolder(string folderPath)
        {
            DirectoryInfo di = new DirectoryInfo(folderPath);
            IList<ExtractorResultObject> resultList = new List<ExtractorResultObject>();
            string[] fileNames = Directory.GetFiles(folderPath, "*.eml", SearchOption.AllDirectories);
            foreach (string fileName in fileNames)
            {
                FileInfo fi = new FileInfo(fileName);
                ContentExtractor ce = new ContentExtractor(fi.FullName);
                ce.ExtractInfo();
                resultList.Add(ce.ResultObject);
            }
            SaveResultList(resultList);
        }
       public   void SaveResultList(IList<ExtractorResultObject> resultList)
        {
            IList<ExtractorResultObject> existsList = new List<ExtractorResultObject>();
            IList<ExtractorResultObject> removeExistsList =
                persistent.RemoveExists(resultList, out existsList);
            foreach (ExtractorResultObject o in existsList)
            {
                EELog.EELogger.Debug(string.Format("Exists:\"{0}\"", o.EmailTitle));
            }
            persistent.SaveBatch(removeExistsList);
        }

       public IList<ExtractorResultObject> GetList(DateTime begin, DateTime end)
       {
           return persistent.GetList(begin, end);
       }
      
    }
}

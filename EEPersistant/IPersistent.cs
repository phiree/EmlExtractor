using System;
using System.Collections.Generic;

using System.Text;
using EEModel;
namespace EEPersistant
{
    public interface IPersistent
    {
        void SaveBatch(IList<EEModel.ExtractorResultObject> resultObjectList);
        IList<EEModel.ExtractorResultObject> RemoveExists(
               IList<EEModel.ExtractorResultObject> resultObjectList
            , out IList<EEModel.ExtractorResultObject> dulpObject);
        /*
         (InquiryTime + ClerkName
                + ProductName + CustomCountry
                + CustomEmail + CustomName).GetHashCode();
         */
        IList <EEModel.ExtractorResultObject>  GetList(
            DateTime beginRequiryTime,DateTime endRequiryTime);
     
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EEModel;
namespace EEPersistant
{
    public interface IPersistent
    {
        void Save(ExtractorResutObject resultObject);
    }
}

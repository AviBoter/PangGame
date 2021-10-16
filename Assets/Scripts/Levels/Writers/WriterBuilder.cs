using System.Collections.Generic;
using System.IO;

namespace writers
{
    public class WriterBuilder
    {
        public static IFileWriter GetFileWriter(string fullPathToFile)
        {
            var fileExtension = "a"; //= Path.GetExtension(fullPathToFile).ToLower();

            if (fileExtension == ".json")
            {
                return new MyJsonWriter();
            }
            else if (fileExtension == ".xml")
            {
              //  return new MyXmlWriter();
            }
            //else if (fileExtension == AnyOtherType)
            return null; //  return new AnyOtherTypeOfWriter();
        }
    }
}

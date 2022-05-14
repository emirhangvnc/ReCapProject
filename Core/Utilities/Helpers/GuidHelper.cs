using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public class GuidHelper
    {
        public static string CreateGuild()
        {
            return Guid.NewGuid().ToString();
            //Yüklenen Dosyanın Benzersiz İsime Sahip Olaması İçin
        }
    }
}

using System;

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

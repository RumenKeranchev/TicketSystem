using Microsoft.AspNetCore.Mvc.ViewFeatures;
using TicketSystem.Common.Contstants;

namespace TicketSystem.Web.Extensions
{
    public static class TempDataDictionaryExtensions
    {
        public static void AddSuccessMessage( this ITempDataDictionary tempData, string message )
        {
            tempData[ WebConstants.TempDataSuccessMessageKey ] = message;
        }

        public static void AddErrorMessage( this ITempDataDictionary tempData, string message )
        {
            tempData[ WebConstants.TempDataErrorMessageKey ] = message;
        }
    }
}
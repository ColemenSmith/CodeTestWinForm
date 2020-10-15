using Google.Apis.Customsearch.v1;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTestWinForm
{
    public static class ImageGrabber
    {
        public static List<resultModel> ExtractCustomSearchData(string searchText)
        {

            const string apiKey = "AIzaSyDIOMWSpB3Wbd2UJZ1N60Z_YVmTwRqfrW0";
            const string searchEngineId = "4c89f90a5035fdbb1";
            string query = searchText;

            var svc = new Google.Apis.Customsearch.v1.CustomsearchService(new BaseClientService.Initializer { ApiKey = apiKey });
            var listRequest = svc.Cse.List();
            listRequest.Q = query;
            listRequest.SearchType = CseResource.ListRequest.SearchTypeEnum.Image;

            listRequest.Cx = searchEngineId;

            List<resultModel> dataModel = new List<resultModel>();
            var count = 0;
            while (dataModel != null)
            {
                listRequest.Start = count;
                listRequest.Execute().Items?.ToList().ForEach(x => dataModel.Add(new resultModel
                {
                    Link = x.Link,
                }));
                count++;
                if (count >= 10)
                {
                    break;
                }
            }
            return dataModel;
        }
    }
}

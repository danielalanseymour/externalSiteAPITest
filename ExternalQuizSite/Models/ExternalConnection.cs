using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;


/*** 
============================================================================================================================================    GetShopify
============================================================================================================================================
    GetShopify: This is the class that accesses Shopify and returns different API strings
        GetShop: Returns store information

============================================================================================================================================
============================================================================================================================================
****/


namespace ExternalQuizSite.Models {

    public class ExternalConnection {

        /*******************************************************************************************************************       GetCredential
            GetCredential: returns the credentials for accessing shopify
                @param privateKey:
                @param password:
                @param returnURL: the URL that the site will be returning                
                @return the access credential string
        *******************************************************************************************************************/

        private static CredentialCache GetCredential(string privateKey, string password, string returnURL) {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var credentialCache = new CredentialCache();
            credentialCache.Add(new Uri(returnURL), "Basic", new NetworkCredential(privateKey, password));
            return credentialCache;
        }







        /** ******************************************************************************       Everything
            Product: Returns Everything
                @param long productID
                @see GetProductCount
                @see EverythingFromShopify
                @return Product
        *********************************************************************************/
        public void SaveQuiz(API api) {


            var request = (HttpWebRequest)WebRequest.Create(api.ReturnURL);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Credentials = GetCredential(api.PrivateKey, api.PrivatePassword, api.ReturnURL);

            request.PreAuthenticate = true;

            using (var response = (HttpWebResponse)request.GetResponse()) {
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12; 

                if (response.StatusCode != HttpStatusCode.OK) {
                    string message = String.Format("Call failed.  Received HTTP {0}", response.StatusCode);
                    throw new ApplicationException(message);
                }
                else {
                    var streamReader = new StreamReader(response.GetResponseStream());
                    //return streamReader.ReadToEnd();
                }
            }
        }






        private Quiz GenerateDefaultQuiz(int id) {
            GetQuiz get = new GetQuiz();
            return get.DefaultQuiz(" Quiz " + id);
        }



    }
}
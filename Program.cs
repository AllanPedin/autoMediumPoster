using RestSharp;
namespace ConsoleApp1
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            MediumPoster medium = new MediumPoster();
            medium.Post("One more test before shove off", "<p>Cache invalidation</p><p>Naming things</p>", "https://www.singlestoneconsulting.com/", "\"developmentals\", \"designerinos\"");
        }
    }
    public class MediumPoster
    {
        public MediumPoster() {
        }
        /*title=just a string containing the title of the post */
        /*body=html formatted string containing the body of the post (Example:<p>Cache invalidation</p><p>Naming things</p>)*/
        /*url=canonical url in string format (Example: https://www.singlestoneconsulting.com/ )*/ //broken maybe (sends it in the body but im not sure if the api uses it)
        /*tags=list of tags as a string formatted as so: (\"development\", \"design\") -no parens -\" indicates escaped qoute(necessary)*/
        public void Post(string title, string body, string url, string tags)
        {
            /*id of account to be posted to*/
            /*how get this? log into medium account, go to settings, create a new integration token,
             Go to postman send a get request to "https://api.medium.com/v1/me" in postman under authorization use
             OAuth2.0 and use your integration token as the access token, in the body of the response your userID will 
             follow "id:" under data*/
            string userID = "19a2c10fb1a720552724c7660efea302754fb226d6e710ba27c39e9abfadd6c10";
            /*integration token of account to be posted to*/
            /*how get? go to medium website, login, go to settings scroll down to Integration tokens, create new integration token
             * copy and paste, thats your token*/
            string token = "29dbab20d2aedaf422b03cdd9d6ac1793c4f8289759fb9bdb5c811f888a62e8cb";
            /*publish status of this post....(“public”, “draft”, or “unlisted”)*/
            string publishStatus = "public";


            var client = new RestClient("https://api.medium.com/v1/users/" + userID + "/posts");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Postman-Token", "f3e31120-dab2-41cc-99a2-8d9b5c3008a0");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Authorization", "Bearer " + token);
            request.AddHeader("Host", "api.medium.com");
            request.AddHeader("Accept-Charset", "utf-8");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\r\n  \"title\": \""+title+"\",\r\n  \"contentFormat\": \"html\",\r\n  \"content\": \""+body+"\",\r\n  \"canonicalUrl\": \""+url+"\",\r\n  \"tags\": ["+tags+"],\r\n  \"publishStatus\": \""+publishStatus+"\"\r\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
        }
    }
}


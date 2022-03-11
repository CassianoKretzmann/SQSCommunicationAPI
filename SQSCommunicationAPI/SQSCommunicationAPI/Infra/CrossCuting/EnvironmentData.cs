using Amazon;
using Amazon.Runtime;
using Amazon.SQS;

namespace SQSCommunicationAPI.Infra.CrossCuting
{
    public class EnvironmentData
    {
        
        public static string QUEUE_URL = "QUEUE_URL";
        public static string ACCESS_KEY = "ACCESS_KEY";
        public static string SECRET_KEY = "SECRET_KEY";

        private static BasicAWSCredentials GetSQSCredentials()
        {
            return new BasicAWSCredentials(ACCESS_KEY, SECRET_KEY);
        }

        public static AmazonSQSClient GetSQSClient()
        {
            return new AmazonSQSClient(GetSQSCredentials(), RegionEndpoint.USEast1);
        }

        //Receive message properties in seconds(can be edited to interfere on the execition of the background processor)
        public static int WaitTime = 10;
        public static int VisibilityTimeOut = 0;
    }
}

using Amazon;
using Amazon.Runtime;
using Amazon.SQS;

namespace SQSCommunicationAPI.Infra.CrossCuting
{
    public class EnvironmentData
    {
        
        public static string QUEUE_URL = "https://sqs.us-east-1.amazonaws.com/816192127034/Alura_queue";
        public static string ACCESS_KEY = "AKIA34CGXQA5OTHR3DF6";
        public static string SECRET_KEY = "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";

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

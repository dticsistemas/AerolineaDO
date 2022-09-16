using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Amazon.SQS;
//using Amazon.SQS.Model;
//using Amazon.Runtime;
//using Amazon;

namespace ControlDocumentoFactura.WebApi {
	public class Program {
		private const int MaxMessages = 1;
		private const int WaitTime = 2;
		public static void Main(string[] args) {
			CreateHostBuilder(args).Build().Run();

			// Do some checks on the command-line  static async Task Main(string[] args)
			/*var urlSqs = "https://sqs.us-east-1.amazonaws.com/191300708619/flights_queue";
			//if (args.Length == 0)
			//{
				//Console.WriteLine("\nUsage: SQSReceiveMessages queue_url");
				//Console.WriteLine("   queue_url - The URL of an existing SQS queue.");
				//return;
			//}
			//if (!args[0].StartsWith("https://sqs."))
			Console.WriteLine("0000000000000000000000000000");
			if (!urlSqs.StartsWith("https://sqs."))
			{
				Console.WriteLine("\nThe command-line argument isn't a queue URL:");
				Console.WriteLine($"{urlSqs}");
				return;
			}
			Console.WriteLine("11111111111111111111111111111111");

			// Create the Amazon SQS client
			var credentials = new BasicAWSCredentials("AKIASZCTJFEF5SCG2NER", "BNtucpVjRgHZ23lB9tAMj93fq3JsS3XL3he0qb6+");
			var sqsClient = new AmazonSQSClient(RegionEndpoint.USEast1);

			// (could verify that the queue exists)
			// Read messages from the queue and perform appropriate actions
			Console.WriteLine($"Reading messages from queue\n  {urlSqs}");
			Console.WriteLine("Press any key to stop. (Response might be slightly delayed.)");
			do
			{
				Console.WriteLine("333333333333333333333");
				var msg = await GetMessage(sqsClient, urlSqs, WaitTime);
				if (msg.Messages.Count != 0)
				{
					if (ProcessMessage(msg.Messages[0]))
						await DeleteMessage(sqsClient, msg.Messages[0], urlSqs);
				}
			} while (!Console.KeyAvailable);
			*/
		}

		
    // Method to read a message from the given queue
    // In this example, it gets one message at a time
    /*private static async Task<ReceiveMessageResponse> GetMessage(
						IAmazonSQS sqsClient, string qUrl, int waitTime = 0)
		{
			return await sqsClient.ReceiveMessageAsync(new ReceiveMessageRequest
			{
				QueueUrl = qUrl,
				MaxNumberOfMessages = MaxMessages,
				WaitTimeSeconds = waitTime
				// (Could also request attributes, set visibility timeout, etc.)
			});
		}


		//
		// Method to process a message
		// In this example, it simply prints the message
		private static bool ProcessMessage(Message message)
		{
			Console.WriteLine($"\nMessage body of {message.MessageId}:");
			Console.WriteLine($"{message.Body}");
			return true;
		}


		//
		// Method to delete a message from a queue
		private static async Task DeleteMessage(
				IAmazonSQS sqsClient, Message message, string qUrl)
		{
			Console.WriteLine($"\nDeleting message {message.MessageId} from queue...");
			await sqsClient.DeleteMessageAsync(qUrl, message.ReceiptHandle);
		}

		*/
	public static IHostBuilder CreateHostBuilder(string[] args) =>
				Host.CreateDefaultBuilder(args)
					.ConfigureWebHostDefaults(webBuilder => {
						webBuilder.UseStartup<Startup>();

					});
	}
				
}

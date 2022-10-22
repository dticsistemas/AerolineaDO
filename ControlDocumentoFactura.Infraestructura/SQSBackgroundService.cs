
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime;
using Amazon.SQS;
using Amazon.SQS.Model;
using ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Vuelos.CrearVuelo;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;
using ThirdParty.Json.LitJson;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System.Data;
using Newtonsoft.Json;
using ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Clientes.CrearCliente;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System.Xml.Linq;
using ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Reservas;
using Nancy.Json;
using Nancy;

namespace ControlDocumentoFactura.WebApi
{
	public class SqsBackgroundService : BackgroundService
	{
		private readonly ILogger<SqsBackgroundService> _logger;

		public IServiceProvider Services { get; }

		public SqsBackgroundService(ILogger<SqsBackgroundService> logger, IServiceProvider service)
		{
			_logger = logger;
			Services = service;

		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{


			_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);



			var accessKey = "AKIASZCTJFEF5SCG2NER";// _configuration.GetValue<string>("AccessKey");
			var secretKey = "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";// _configuration.GetValue<string>("SecretKey");
			var myQueueUrl = "https://sqs.us-east-1.amazonaws.com/191300708619/invoices_queue";// _configuration.GetValue<string>("myQueueUrl");




			var credentials = new BasicAWSCredentials(accessKey, secretKey);

			Console.WriteLine("\nThe command-line argument isn't a queue URL:");
			Console.WriteLine($"{myQueueUrl}");

			var sqsClient = new AmazonSQSClient(credentials, RegionEndpoint.USEast1);
			await Start(sqsClient, myQueueUrl, stoppingToken);

		}

		private async Task Start(IAmazonSQS sqsClient, string myQueueUrl, CancellationToken stoppingToken)
		{
			Console.WriteLine($"Starting polling queue");
			Console.WriteLine($"Reading messages from queue\n  {myQueueUrl}");
			Console.WriteLine("Press any key to stop. (Response might be slightly delayed.)");
			do
			{
				var msg = await GetMessage(sqsClient, myQueueUrl, 3);
				if (msg.Messages.Count != 0)
				{
					if (ProcessMessage(msg.Messages[0]))
					{
						Amazon.SQS.Model.Message message = msg.Messages[0];
						//Console.WriteLine($"\nMessage body of {message.MessageId}:");
						//Console.WriteLine($"{message.Body}");
						JObject jsonDataParent = JObject.Parse(message.Body);

						var mensaje = message.Body;

						var cadena = jsonDataParent["Message"].ToString();
						var eventoTopic = jsonDataParent["TopicArn"].ToString();
						//var cadena = Convert.ToString(jsonDataParent.Message);
						dynamic jsonData = JObject.Parse(cadena);
						JObject obj = JObject.Parse(cadena);
						string method1_timestamp = (string)obj["event"];

						JavaScriptSerializer serializer = new JavaScriptSerializer();
						dynamic item = serializer.Deserialize<object>(cadena);
						//string namee = item["event"];
						//var nameEvent = "";// jsonData.get;
						var jDatos = jsonData.data;

						try
						{
							if (eventoTopic == "arn:aws:sns:us-east-1:191300708619:VueloCreado")
							{
								var uuid = jDatos.flight_program.uuid;
								//var flight = jDatos.flight;
								//var uuid_flight = glifht.uuid;
								var origen = jDatos.flight_program.sourceAirport;
								var destino = jDatos.flight_program.destinyAirport;
								var flight_program_id = jDatos.flight.id;
								var datos = jDatos.flight.created_at;
								var status = "null";

								try
								{
									CrearVueloCommand objVueloCommand = new CrearVueloCommand(Guid.Parse(uuid.ToString()), Int32.Parse(flight_program_id.ToString()), origen.ToString(), destino.ToString(), status.ToString(), datos.ToString());
									using (var scope = Services.CreateScope())
									{
										var _mediator =
										scope.ServiceProvider
										.GetRequiredService<IMediator>();
										Guid idResponse = await _mediator.Send(objVueloCommand);

									}
								}
								catch (Exception e)
								{
									Console.WriteLine("{0} Exception caught.", e);
								}
							}

							else if (eventoTopic == "arn:aws:sns:us-east-1:191300708619:PasajeroCreado")
							{
								jDatos = jsonData.body.passanger;
								var id = jDatos.id;
								var name = jDatos.name;
								var lastName = jDatos.lastName;
								var passport = jDatos.passport;
								var needsAssistance = jDatos.needsAssistance;
								try
								{
									CrearClienteCommand objClienteCommand = new CrearClienteCommand(Guid.Parse(id.ToString()), name.ToString(), lastName.ToString(), passport.ToString(), needsAssistance.ToString(), "null", "test@gmail.com", "null");
									using (var scope = Services.CreateScope())
									{
										var _mediator =
										scope.ServiceProvider
										.GetRequiredService<IMediator>();
										Guid idResponse = await _mediator.Send(objClienteCommand);
										//_logger.LogInformation("Get me the Response: {resopnse}", await mediator.Send(new SampleQuery()));
									}

								}
								catch (Exception e)
								{
									Console.WriteLine("{0} Exception caught.", e);
								}
							}

							else if (eventoTopic == "arn:aws:sns:us-east-1:191300708619:ReservaCreada")
							{
								jDatos = jsonData;//.body.booking;
								var id = jDatos.id;
								var reservationNumber = jDatos.reservationNumber.data;
								var passanger = jDatos.passanger;
								var reservationStatus = jDatos.reservationStatus.data;
								var fecha = "2022-10-01";// now.ToString();//jDatos.date;
								var monto = jDatos.accountReceivable.originalValue.data;
								var flight = jDatos.flight;
								try
								{
									CrearReservaCommand objReservaCommand = new CrearReservaCommand(Guid.Parse(id.ToString()), reservationNumber.ToString(), Guid.Parse(passanger.ToString()), Guid.Parse(flight.ToString()), fecha.ToString(), Convert.ToDecimal(monto.ToString()), reservationStatus.ToString());
									using (var scope = Services.CreateScope())
									{
										var _mediator =
										scope.ServiceProvider
										.GetRequiredService<IMediator>();
										Guid idResponse = await _mediator.Send(objReservaCommand);
									}
								}
								catch (Exception e)
								{
									Console.WriteLine("{0} Exception caught.", e);
								}
							}

							else if (eventoTopic == "arn:aws:sns:us-east-1:191300708619:ReservaPagada")
							{
								var id = Guid.NewGuid();
								var transactionNumber = jDatos.transactionNumber;
								var amount = jDatos.amount;
								var booking = jDatos.booking;
								try
								{
									ReservaPagadoCommand objReservaPagadoCommand = new ReservaPagadoCommand(Guid.Parse(id.ToString()), Guid.Parse(booking.ToString()), transactionNumber.ToString(), Convert.ToDecimal(amount.ToString()));
									using (var scope = Services.CreateScope())
									{
										var _mediator =
										scope.ServiceProvider
										.GetRequiredService<IMediator>();
										Guid idResponse = await _mediator.Send(objReservaPagadoCommand);
									}
								}
								catch (Exception e)
								{
									Console.WriteLine("{0} Exception caught.", e);
								}
							}
						}
						catch (Exception e)
						{
							//await DeleteMessage(sqsClient, msg.Messages[0], myQueueUrl);
						}




					}

					await DeleteMessage(sqsClient, msg.Messages[0], myQueueUrl);

				}
			} while (!Console.KeyAvailable || !stoppingToken.IsCancellationRequested);
		}
		//
		// Method to read a message from the given queue
		// In this example, it gets one message at a time
		private static async Task<ReceiveMessageResponse> GetMessage(
				IAmazonSQS sqsClient, string qUrl, int waitTime = 0)
		{
			return await sqsClient.ReceiveMessageAsync(new ReceiveMessageRequest
			{
				QueueUrl = qUrl,
				MaxNumberOfMessages = 1,
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
			//dynamic jsonData = JObject.Parse(message.Body);			

			//CrearVueloCommand objVueloProducto = new CrearVueloCommand(uuid,cantidad,detalle,precioPasaje);
			//_mediator.Send(command);*/
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


	}
}

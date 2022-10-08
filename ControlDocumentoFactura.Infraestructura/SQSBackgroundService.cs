
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

namespace ControlDocumentoFactura.WebApi
{
	public class SqsBackgroundService : BackgroundService
	{
		private readonly IConfiguration _configuration;
		private readonly IMediator _mediator;

		public SqsBackgroundService(IConfiguration configuration, IMediator mediator)
		{
			_configuration = configuration;
			_mediator = mediator;
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{

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
					try {		
				//	JObject obj = JObject.Parse(mensaje);
				//	JObject jo = (JObject)JsonConvert.DeserializeObject(mensaje);
				//	string zone = jo["Message"].ToString();
					}
					catch (Exception e)
					{
						Console.WriteLine("{0} Exception caught.", e);
					}


					var cadena = jsonDataParent["Message"].ToString();
					//var cadena = Convert.ToString(jsonDataParent.Message);
					dynamic jsonData = JObject.Parse(cadena);
					var nameEvent = jsonData.nameEvent;
					var jDatos = jsonData.data;
					
					try
					{
						if (nameEvent == "FlightCreated")
						{
							var uuid = jDatos.uuid;
							var origen = jDatos.source_airport_code;
							var destino = jDatos.destiny_airport_code;							
							var flight_program_id = jDatos.flight_program_id;
							var datos = jDatos.datos;						
							//CrearVueloCommand command = new CrearVueloCommand(uuid, cantidad, detalle, precioPasaje);
							String query = "INSERT INTO dbo.Vuelo(Id,source_airport_code,destiny_airport_code,flight_program_id,information) VALUES (" +
								"CONVERT(uniqueidentifier,'" + uuid.ToString() + "'),'" +
									Convert.ToString(origen) + "','" + Convert.ToString(destino) +
									"','" + Convert.ToString(flight_program_id) + "','" + Convert.ToString(datos) + "')";
							try
							{
								using (SqlConnection connection = new SqlConnection("Server=mysqlserverinvoices.database.windows.net;Database=DBFacturas;User=usuarioinvoices;Password=password123!"))
								{
									connection.Open();
									using (SqlCommand cmd = new SqlCommand(query, connection))
									{
										cmd.CommandType = CommandType.Text;
										cmd.ExecuteNonQuery();
									}
								}
							}
							catch (Exception e)
							{
								Console.WriteLine("{0} Exception caught.", e);
							}
						}

						else if (nameEvent == "PassangerCreated")
						{
							var id = jDatos.id;
							var name = jDatos.name;
							var lastName = jDatos.lastName;
							var passport = jDatos.passport;
							var needsAssistance = jDatos.needsAssistance;

							//CrearVueloCommand command = new CrearVueloCommand(id, cantidad, detalle, precioPasaje);
							String query = "INSERT INTO dbo.Cliente(Id,nombreCompleto,name,lastName,passport,needAssistance) VALUES (" +
								"CONVERT(uniqueidentifier,'" + id.ToString() + "'),'" + Convert.ToString(name) + " " + Convert.ToString(lastName) + "','" + Convert.ToString(name) + "','" + Convert.ToString(lastName) + "','" + Convert.ToString(passport)
								+ "','" + Convert.ToString(needsAssistance) + "')";
							try
							{
								using (SqlConnection connection = new SqlConnection("Server=mysqlserverinvoices.database.windows.net;Database=DBFacturas;User=usuarioinvoices;Password=password123!"))
								{
									connection.Open();
									using (SqlCommand cmd = new SqlCommand(query, connection))
									{
										cmd.CommandType = CommandType.Text;
										cmd.ExecuteNonQuery();
									}
								}
							}
							catch (Exception e)
							{
								Console.WriteLine("{0} Exception caught.", e);
							}
						}

						else if (nameEvent == "BookingCreated")
						{
							var id = jDatos.id;
							var reservationNumber = jDatos.reservationNumber;
							var passanger = jDatos.passanger;
							var reservationStatus = jDatos.reservationStatus;
								//DateTime now = DateTime.Now;
								var date = "2022-10-01";// now.ToString();//jDatos.date;
							var value = jDatos.value;
							var flight = jDatos.flight;
							//CrearVueloCommand command = new CrearVueloCommand(id, cantidad, detalle, precioPasaje);
							String query = "INSERT INTO dbo.Reserva(Id,reservationNumber,monto,deuda,fecha,tipoReserva,ClienteId,VueloId,reservationStatus) VALUES (" +
							"CONVERT(uniqueidentifier,'" + id.ToString() + "'),'" + Convert.ToString(reservationNumber) + "','" + Convert.ToString(value) + "','0','" + Convert.ToString(date) +
							"','R',CONVERT(uniqueidentifier,'" + Convert.ToString(passanger) + "'),CONVERT(uniqueidentifier,'" + Convert.ToString(flight) + "'),'" + Convert.ToString(reservationStatus) + "')";
							try
							{
								using (SqlConnection connection = new SqlConnection("Server=mysqlserverinvoices.database.windows.net;Database=DBFacturas;User=usuarioinvoices;Password=password123!"))
								{
									connection.Open();
									using (SqlCommand cmd = new SqlCommand(query, connection))
									{
										cmd.CommandType = CommandType.Text;
										cmd.ExecuteNonQuery();
									}
								}
							}
							catch (Exception e)
							{
								Console.WriteLine("{0} Exception caught.", e);
							}
						}

						else if (nameEvent == "PaymentCreated")
						{
							var id = Guid.NewGuid();
							var transactionNumber = jDatos.transactionNumber;
							var amount = jDatos.amount;
							var booking = jDatos.booking;
							var fecha = jDatos.created_at;
							//CrearVueloCommand command = new CrearVueloCommand(id, cantidad, detalle, precioPasaje);
							String query = "INSERT INTO dbo.Pago(Id,monto,fecha,codComprobante,ReservaId) VALUES ( CONVERT(uniqueidentifier,'" + id.ToString() + "')" +
								",'" + Convert.ToString(amount) + "','" + Convert.ToString(fecha) + "','ABCDE',CONVERT(uniqueidentifier,'" + Convert.ToString(booking) + "') )";
							try
							{
								using (SqlConnection connection = new SqlConnection("Server=mysqlserverinvoices.database.windows.net;Database=DBFacturas;User=usuarioinvoices;Password=password123!"))
								{
									connection.Open();
									using (SqlCommand cmd = new SqlCommand(query, connection))
									{
										cmd.CommandType = CommandType.Text;
										cmd.ExecuteNonQuery();
									}
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

using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RestSharp.Authenticators;
using RestSharp;
using Serilog.Events;
using Serilog;
using System.Net;
using DigiProj.Configuration.Constants;
using DigiProj.Configuration;
using DigiProj.Shared.Dtos.Responses;

namespace DigiProj.Helpers
{
	public static class ApiHelper
	{
		public static void CreateLog(IRestRequest request, IRestResponse response)
		{
			var guid = Guid.NewGuid();

			//Request
			var message = $"{guid} Request {request.Method} {request.Resource}{Environment.NewLine}";
			foreach (var param in request.Parameters)
				message += $"   [{request.Parameters.IndexOf(param)}] {param.Type} {param.Value}{Environment.NewLine}";

			Log.Error(message.TrimEnd(Environment.NewLine.ToCharArray()));


			//Response 
			message = $"{guid} Response {(int)response.StatusCode} {response.ContentType}{Environment.NewLine}{response.Content}";
			Log.Error(message);
		}

		public static void CheckConnection(this ApiConfiguration configuration)
		{
			var client = new RestClient(configuration.BaseUrl);
			var request = new RestRequest(configuration.UriCheckConnection, Method.GET);
			request.AddRequiredHeaders(configuration);
			request.Timeout = 20000;
			var response = client.Execute(request);

			if (!response.IsSuccessful)
			{
				throw new Exception(ConfigurationConsts.ErrorMessageUnableConnectApi, response.ErrorException);
			}
		}

		public static void CheckError(this IRestResponse response, IRestRequest request)
		{
			if (Log.IsEnabled(LogEventLevel.Debug))
				CreateLog(request, response);

			if (!string.IsNullOrEmpty(response.ErrorMessage))
				throw response.ErrorException;

			if (!response.ContentType.Contains(ApiConsts.ContentType) ||
				response.StatusCode is HttpStatusCode.InternalServerError or HttpStatusCode.Unauthorized)
			{
				CreateLog(request, response);
				throw new InvalidOperationException("Api Error", response.ErrorException);
			}

		}

        public static IRestClient AddAuthenticator(this IRestClient client, TokenResponse token)
		{
			client.Authenticator = new JwtAuthenticator(token.Token);
			client.Timeout = ApiConsts.TimeoutMedium;
			return client;
		}

		public static IRestRequest AddRequiredHeaders(this IRestRequest request, ApiConfiguration apiConfig)
		{
			//Header Api Key
			request.AddHeader(ConfigurationConsts.ApiKeyHeaderKey, apiConfig.ApiKey);

			return request;
		}

		public static IRestRequest AddRequiredBody(this IRestRequest request, object requestDto)
		{
			request.AddJsonBody(JsonConvert.SerializeObject(requestDto, JsonSerializationHelper.SnakeCaseSettings));

			return request;
		}

		public static T GetContent<T>(this IRestResponse response)
		{
			var responseDto = JsonConvert.DeserializeObject<T>(response.Content, JsonSerializationHelper.SnakeCaseSettings);
			return responseDto;
		}

	}
}

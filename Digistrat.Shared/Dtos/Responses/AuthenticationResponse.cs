using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digistrat.Shared.Dtos.Responses
{
    public class TokenResponse
    {
        public int Code { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        public DateTime ExpiredTime { get; set; }
        public double ExpiresIn { get; set; }
        public string Token { get; set; }
        public string TokenType
        {
            get { return "Bearer"; }
        }
        public string RefreshToken { get; set; }
    }

	public class MaintenanceResponse
	{
		public bool Enabled { get; set; }
	}
}

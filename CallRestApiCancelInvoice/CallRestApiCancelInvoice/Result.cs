using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallRestApiCancelInvoice
{
	public class Result
	{
		public Result() 
		{ 
		}

		public string Value { get; set; }
		public bool IsFailed { get; set; }
		public bool IsSuccess { get; set; }
		public List<object> Errors { get; set; }
		public List<object> Successes { get; set; }
	}
}
